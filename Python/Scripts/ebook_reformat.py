import os

path = (r"C:\Users\Jacob\Downloads\97-Things-Every-Programmer-Should-Know-Extended\OEBPS\\")

for fn in os.listdir(path):
    
    if (os.path.isfile(path + fn)) and (".xhtml" in fn) and ("chap" in fn):
        file = open(path + fn, encoding ='utf8').read()
        ind_s = file.find('<hr class="scene-break" /><p>This work is licensed under a')
        file_n = file[:ind_s]+"</div>\n</body>\n</html>"
        file = open(path + fn, 'w', encoding='utf8')
        file.write(file_n)
        file.close()
