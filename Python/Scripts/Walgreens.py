import argparse, time, random, sys, Tkinter as tk
from selenium import webdriver
from selenium.webdriver.common.action_chains import ActionChains

#imports
def autofill_wal():
        #input arguments
        ##ap = argparse.ArgumentParser()
        ##ap.add_argument("-n", "--number", required=True)
        ##ap.add_argument("-p", "--password", required=True)
        ##args = vars(ap.parse_args())
        args = {}
        args["number"] = s_field.get()
        args["password"] = p_field.get()
        survey1, survey2, survey3 = args["number"].split("-")
        password1, password2, password3 = args["password"].split("-")

        # survey1 = '0426'
        # survey2 = '0019'
        # survey3 = '223'

        # password1 = '2160'
        # password2 = '6140'
        # password3 = '321'

        browser = webdriver.Firefox()
        browser.get('http://www.wagcares.com/websurvey/app?gateway=Walgreens')
        # navigate first page
        english = browser.find_element_by_id("imLanguageSelect")
        action = ActionChains(browser)
        action.move_to_element_with_offset(english,50,300)
        action.click()
        action.perform()
        time.sleep(1)
        # enter survey information
        survey = browser.find_element_by_id("pbox1")
        survey.send_keys(survey1)
        survey = browser.find_element_by_id("pbox2")
        survey.send_keys(survey2)
        survey = browser.find_element_by_id("pbox3")
        survey.send_keys(survey3)
        # enter password information
        password = browser.find_element_by_id("pbox4")
        password.send_keys(password1)
        password = browser.find_element_by_id("pbox5")
        password.send_keys(password2)
        password = browser.find_element_by_id("pbox6")
        password.send_keys(password3)
        # submit information
        submit = browser.find_element_by_id("ImageSubmit")
        submit.click()
        try:
                submit = browser.find_element_by_id("ImageSubmit")
                submit.click()
                answers = []
                for i in range(10):
                        answers.append(random.randint(6,8))
                # 17%
                browser.find_element_by_id("RadioGroup8").click()
                browser.find_element_by_id("ImageSubmit").click()

        except:
                browser.close()
                print("The codes have expired")
                sys.exit(1)

        # 19%
        browser.find_element_by_id("RadioGroup_28").click()
        browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
        browser.find_element_by_id("RadioGroup_2_1{0}".format(answers[2])).click()
        browser.find_element_by_id("RadioGroup_2_2{0}".format(answers[3])).click()
        browser.find_element_by_id("RadioGroup_2_3{0}".format(answers[4])).click()
        browser.find_element_by_id("RadioGroup_2_4{0}".format(answers[5])).click()
        browser.find_element_by_id("ImageSubmit").click()
        # 20%
        browser.find_element_by_id("RadioGroup{0}".format(answers[6])).click()
        browser.find_element_by_id("ImageSubmit").click()
        # 22%
        browser.find_element_by_id("RadioGroup{0}".format(answers[7])).click()
        browser.find_element_by_id("ImageSubmit").click()
        # 26%
        browser.find_element_by_id("RadioGroup2").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 43%
        browser.find_element_by_id("RadioGroup{0}".format(answers[8])).click()
        browser.find_element_by_id("ImageSubmit").click()
        # 45%
        browser.find_element_by_id("RadioGroup_28").click()
        browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
        browser.find_element_by_id("RadioGroup_2_1{0}".format(answers[2])).click()
        browser.find_element_by_id("RadioGroup_2_2{0}".format(answers[3])).click()
        browser.find_element_by_id("ImageSubmit").click()
        # 48%
        browser.find_element_by_id("RadioGroup1").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 50%
        browser.find_element_by_id("RadioGroup_28").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 59%
        browser.find_element_by_id("RadioGroup1").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 63%
        browser.find_element_by_id("RadioGroup3").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 65%
        browser.find_element_by_id("RadioGroup0").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 70%
        browser.find_element_by_id("RadioGroup1").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 72%
        browser.find_element_by_id("RadioGroup8").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 74%
        browser.find_element_by_id("RadioGroup_28").click()
        browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
        # 77%
        browser.find_element_by_id("RadioGroup6").click()
        browser.find_element_by_id("ImageSubmit").click()
        #17th page
        browser.find_element_by_id("RadioGroup0").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 84%
        browser.find_element_by_id("promptInput_215930").send_keys("The store is always so clean and" 
                " items are so easy to find")
        browser.find_element_by_id("ImageSubmit").click()	
        # 19th page
        browser.find_element_by_id("RadioGroup1").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 20th page
        browser.find_element_by_id("RadioGroup2").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 21st page
        browser.find_element_by_id("RadioGroup1").click()
        browser.find_element_by_id("ImageSubmit").click()
        # 22nd page
        browser.find_element_by_id("RadioGroup0").click()
        browser.find_element_by_id("ImageSubmit").click()
        # final page
        browser.find_element_by_id("promptInput_76122").send_keys('Jacob Scherber')
        browser.find_element_by_id("promptInput_76123").send_keys('6127090685')
        browser.find_element_by_id("promptInput_76124").send_keys('1010 Lake St NE Apt 222')
        browser.find_element_by_id("promptInput_76125").send_keys('Hopkins')
        browser.find_element_by_id("promptInput_76126").send_keys('MN')
        browser.find_element_by_id("promptInput_76127").send_keys('55343')

top = tk.Tk()
top.title("Walgreens Survey Auto-Fill")
survey_label = tk.Label(top, text="Survey Number")
survey_label.pack()
s_field = tk.Entry(top)
s_field.pack()
pass_label = tk.Label(top, text="Password")
pass_label.pack()
p_field = tk.Entry(top)
p_field.pack()
B = tk.Button(top, text="Submit", command=autofill_wal)
B.pack()


top.mainloop()
