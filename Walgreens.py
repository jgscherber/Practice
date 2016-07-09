#Walgreens.py -n "0426-0019-223" -p "2160-6140-321"

#imports

import argparse
import time
import random
from selenium import webdriver
from selenium.webdriver.common.action_chains import ActionChains

#input arguments
##ap = argparse.ArgumentParser()
##ap.add_argument("-n", "--number", required=True)
##ap.add_argument("-p", "--password", required=True)
##args = vars(ap.parse_args())
args = {}
args["number"] = "0426-0014-815"
args["password"] = "5160-7070-321"
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
	#first page
	browser.find_element_by_id("RadioGroup{0}".format(answers[0])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#second page
	browser.find_element_by_id("RadioGroup_28").click()
	browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
	browser.find_element_by_id("RadioGroup_2_1{0}".format(answers[2])).click()
	browser.find_element_by_id("RadioGroup_2_2{0}".format(answers[3])).click()
	browser.find_element_by_id("RadioGroup_2_3{0}".format(answers[4])).click()
	browser.find_element_by_id("RadioGroup_2_4{0}".format(answers[5])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#third page
	browser.find_element_by_id("RadioGroup{0}".format(answers[6])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#forth page
	browser.find_element_by_id("RadioGroup{0}".format(answers[7])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#fifth page
	browser.find_element_by_id("RadioGroup2").click()
	browser.find_element_by_id("ImageSubmit").click()
	#sixth page
	browser.find_element_by_id("RadioGroup{0}".format(answers[8])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#seventh page
	browser.find_element_by_id("RadioGroup_28").click()
	browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
	browser.find_element_by_id("RadioGroup_2_1{0}".format(answers[2])).click()
	browser.find_element_by_id("RadioGroup_2_2{0}".format(answers[3])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#eight page
	browser.find_element_by_id("RadioGroup1").click()
	browser.find_element_by_id("ImageSubmit").click()
	#ninth page
	browser.find_element_by_id("RadioGroup_28").click()
	browser.find_element_by_id("ImageSubmit").click()
	#tenth page
	browser.find_element_by_id("RadioGroup1").click()
	browser.find_element_by_id("ImageSubmit").click()
	#eleventh page
	browser.find_element_by_id("RadioGroup3").click()
	browser.find_element_by_id("ImageSubmit").click()
	#twelth page
	browser.find_element_by_id("RadioGroup0").click()
	browser.find_element_by_id("ImageSubmit").click()
	#thirteenth page
	browser.find_element_by_id("RadioGroup1").click()
	browser.find_element_by_id("ImageSubmit").click()
	#14th page
	browser.find_element_by_id("RadioGroup{0}".format(answers[9])).click()
	browser.find_element_by_id("ImageSubmit").click()
	#15th page
	browser.find_element_by_id("RadioGroup_28").click()
	browser.find_element_by_id("RadioGroup_2_0{0}".format(answers[1])).click()
	#16th page
	browser.find_element_by_id("RadioGroup5").click()
	browser.find_element_by_id("ImageSubmit").click()
	#17th page
	browser.find_element_by_id("RadioGroup1").click()
	browser.find_element_by_id("ImageSubmit").click()
	#18th page
	#???
	
##	# 19th page
##	browser.find_element_by_id("RadioGroup1").click()
##	browser.find_element_by_id("ImageSubmit").click()
##	# 20th page
##	browser.find_element_by_id("RadioGroup2").click()
##	browser.find_element_by_id("ImageSubmit").click()
##	# 21st page
##	browser.find_element_by_id("RadioGroup1").click()
##	browser.find_element_by_id("ImageSubmit").click()
##	# 22nd page
##	browser.find_element_by_id("RadioGroup0").click()
##	browser.find_element_by_id("ImageSubmit").click()
##	# final page
##	browser.find_element_by_id("promptInput_76122").send_keys('Jacob Scherber')
##	browser.find_element_by_id("promptInput_76123").send_keys('6127090685')
##	browser.find_element_by_id("promptInput_76124").send_keys('1010 Lake St NE Apt 222')
##	browser.find_element_by_id("promptInput_76125").send_keys('Hopkins')
##	browser.find_element_by_id("promptInput_76126").send_keys('MN')
##	browser.find_element_by_id("promptInput_76127").send_keys('55343')
except:
	browser.close()
	print("The codes have expired")
