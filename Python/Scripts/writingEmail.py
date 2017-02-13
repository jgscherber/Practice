# https://praw.readthedocs.io

import praw # Reddit API wrapper
import sys, json, smtplib

CLIENTID = sys.argv[1]
PASSWORD = sys.argv[2]

r = praw.Reddit(client_id=CLIENTID,
                client_secret=PASSWORD,
                user_agent='conscioncience')
submissions = r.subreddit('WritingPrompts').top(time_filter='week',
                                                    limit=30)

submissions = [sub for sub in submissions
               if not any(x in sub.title for x in ['[PM]', '[PI]','[CC]','[OT]'])]
submissions = submissions[0:3]

email = sys.argv[3]
password = sys.argv[4]

smtpObj = smtplib.SMTP_SSL('smtp.gmail.com',465)
smtpObj.login(email,password)

smtpObj.sendmail(email,email, 'Subject: Writing Prompts\n'
                 + submissions[0].title + '\n' + submissions[0].shortlink + '\n\n'
                 + submissions[1].title + '\n' + submissions[1].shortlink + '\n\n'
                 + submissions[2].title + '\n' + submissions[2].shortlink + '\n\n')

