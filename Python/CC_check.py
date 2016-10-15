from selenium import webdriver
import datetime, time, selenium, unicodedata, smtplib, sys, schedule
from dateutil.relativedelta import relativedelta



def web_scrape():
    UN = 'jgscherber'
    PW = 'CwburtoN72'
##    driverService = selenium.PhantomJSDriverService.CreateDefaultService()
##    driverService.HideCommandPromptWindow = true
    driver = webdriver.PhantomJS(r'phantomjs.exe')
    #driver = webdriver.Firefox()
    driver.get('https://online.citi.com/US/Welcome.c')
    time.sleep(1)
    driver.find_element_by_id('username').send_keys(UN)
    driver.find_element_by_id('pwd').send_keys(PW)
    driver.find_element_by_id('find-submit').click()
    time.sleep(3)
    # get all relevant elements, easier to grab
    trans_dates_el = driver.find_elements_by_class_name(
        "cA-ada-TransactionDateColumn")
    trans_amounts_el = driver.find_elements_by_class_name(
        "cA-ada-CreditCardTransactionAmountColumn")
    # then grab the text from each element, they're unicode so convert to ascii
    trans_dates = [unicodedata.normalize('NFKD', i.text).encode(
        'ascii','ignore') for i in trans_dates_el]
    trans_amounts = [unicodedata.normalize('NFKD', i.text).encode(
        'ascii','ignore') for i in trans_amounts_el]
    # remove payments from data to only sum charges
    payments = []
    for i in range(len(trans_dates)):
        if trans_amounts[i][0] == '-':
            payments.append(i)
    for i in reversed(payments):
        del trans_amounts[i]
        del trans_dates[i]
    # convert to floats and datetimes for summation later    
    trans_dates = [datetime.datetime.strptime(i, '%b. %d, %Y') for i in trans_dates]
    trans_amounts = [float(i.lstrip('$')) for i in trans_amounts]
    driver.quit()
    
    return trans_dates, trans_amounts

def past_week(trans_dates, trans_amounts):
    today = datetime.date.today()
    weekday = (today.weekday() + 1) % 7
    sunday = today - datetime.timedelta(weekday)
    old_dates = []
    for i in range(len(trans_dates)):
        if trans_dates[i].date() < sunday:
            old_dates.append(i)
    for i in reversed(old_dates):
        del trans_amounts[i]
        del trans_dates[i]
    
    return sum(trans_amounts), weekday
def monthly_tracker(running_tot, weekday):
    f = open("tracking.csv", "r")
    data = f.read()
    f.close()
    data = data.split(",")
    if weekday == 7:
        data.append(str(125-running_tot))
    if data[0] == '':
        monthly_tot = 0
    else:
        monthly_tot = sum([float(i) for i in data])
    f = open("tracking.csv", "w")
    f.write(",".join(data))
    f.close()
    return monthly_tot

    
def clear_montly_tracker():
    open("tracking.csv", "w")

    
def send_email(running_tot, weekday, monthly_diff):
    day_left = 6-weekday
    tot_left = 125-running_tot
    left_day = tot_left / day_left
    smtpObj = smtplib.SMTP_SSL('smtp.gmail.com', 465)
    smtpObj.login('jgscherber@gmail.com', 'YwburtoE72')
    if tot_left >= 0:
        smtpObj.sendmail('jgscherber@gmail.com', 'jgscherber@gmail.com',
                         'Subject: ${0:.2f} Spent in {1} days\nThere is ${2:.2f} left. '
                         'That\'s ${3:.2f} per day.\n\n'
                         'Your monthly budget is off: {4:.2f}'.format(running_tot, weekday+1,
                                                       tot_left, left_day, monthly_diff))
    else:
        smtpObj.sendmail('jgscherber@gmail.com', 'jgscherber@gmail.com',
                         'Subject: ${0:.2f} Spent in {1} days\nThat\'s ${2:.2f} over!'
                         'There\'s {3:.2f} days left! Be frugal!\n\n'
                         'Your monthly budget is off: {4:.2f}'.format(running_tot,
                                                              weekday+1, tot_left,
                                                            day_left, monthly_diff))
    smtpObj.quit()
    

def all_functions():    
    trans_dates, trans_amounts = web_scrape()
    running_tot, weekday = past_week(trans_dates, trans_amounts)
    if datetime.date.today().day == 1:
        clear_monthly_tracker()
    monthly_diff = monthly_tracker(running_tot, weekday)
    send_email(running_tot, weekday, monthly_diff)
    


all_functions()

