import smtplib, sys, random


mantras = ["money","love","compassion","argument","negotiate","anger","hunger","happy","sad"]

selection = random.randint(0,len(mantras)-1) # end is inclusive

# command is python with aguments file_name username password
# sys.argv[0] is the file name
email = sys.argv[1]
password = sys.argv[2]

smtpObj = smtplib.SMTP_SSL('smtp.gmail.com',465)
smtpObj.login(email,password)

smtpObj.sendmail(email,email,'Subject: Daily mantra: {0}'.format(mantras[selection]))
