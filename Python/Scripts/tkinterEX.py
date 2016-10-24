import tkinter as tk

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
B = tk.Button(top, text="Submit")
B.pack()


##for c in sorted(top.children):
##    top.children[c].pack()

# Code to add widgets will go here...
top.mainloop()
