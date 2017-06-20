from pyvirtualdisplay import Display
from selenium import webdriver
import datetime, time, selenium, unicodedata, smtplib, sys
from dateutil.relativedelta import relativedelta
from selenium.webdriver.common import action_chains, keys
from selenium.webdriver.chrome.options import Options

def web_scrape():
    UN = sys.argv[1] #change this to sys.argv[1]
    PW = sys.argv[2]
    # setup driver
    display = Display(visible=0, size=(1200,800))
    display.start()
    chrome_options = Options()
    chrome_options.add_argument("--disable-extensions --start-maximized")    
    driver = webdriver.Chrome(chrome_options=chrome_options)
    #driver = webdriver.Firefox()
    # login
    #print("Logging in...")
    driver.get('https://online.citi.com')
    time.sleep(10)
    password = driver.find_element_by_id('password')
    password.send_keys(PW)
    password.click()
    action = action_chains.ActionChains(driver)
    action.send_keys(keys.Keys.SHIFT + keys.Keys.TAB)
    action.send_keys(UN)
    action.perform()   
    driver.find_element_by_id('signInBtn').click()
    time.sleep(10)
    
    # set range to all time (avoids no charges at end of cycle)
    
    # get all relevant elements, easier to grab
    #print("Getting info...")
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
    trans_amounts = [i.lstrip('$') for i in trans_amounts]
    trans_amounts = [float(i.replace(',','')) for i in trans_amounts]
    
    time.sleep(3)
    driver.close()
    driver.quit()
    display.stop()
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
    f = open("/home/js/CCrun/tracking.csv", "r")
    data = f.read()
    f.close()
    data = data.split(",")
    if weekday == 7:
        data.append(str(125-running_tot))
    if data[0] == '':
        monthly_tot = 0
    else:
        monthly_tot = sum([float(i) for i in data])
    f = open("/home/js/CCrun/tracking.csv", "w")
    f.write(",".join(data))
    f.close()
    return monthly_tot

    
def clear_montly_tracker():
    open("/home/js/CCrun/tracking.csv", "w")

    
def send_email(running_tot, weekday, monthly_diff):
    day_left = 6-weekday
    tot_left = 125-running_tot
    if day_left > 0:
        left_day = tot_left / day_left
    else:
        left_day = tot_left
    smtpObj = smtplib.SMTP_SSL('smtp.gmail.com', 465)
    smtpObj.login(sys.argv[3],sys.argv[4])
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

