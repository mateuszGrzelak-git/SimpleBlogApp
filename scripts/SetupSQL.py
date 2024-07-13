import os.path
import sys
from pathlib import Path

class SQLConfiguration:
    SQLVersion = ""
    SQLExeUrl = ""
    SQLLicenseUrl = ""
    SQLDirectory = "./database"

    @classmethod
    def Validate(cls):
        if (not cls.CheckIfSQLInstalled()):
            print("SQL is not installed")
            return False
        print(f"Correct SQL located at {os.path.abspath(cls.SQLDirectory)}")
        return True

    @classmethod
    def CheckIfSQLInstalled(cls):
        sqlExe = Path(f"{cls.SQLDirectory}")
        if (not sqlExe.exists()):
            return cls.InstallSQL()

        return True

    @classmethod
    def InstallSQL(cls):
        permissionGranted = False
        while not permissionGranted:
            reply = str(input("SQL not found. Would you like to download SQL {0:s}? [Y/N]: ".format(cls.SQLVersion))).lower().strip()[:1]
            if reply == 'n':
                return False
            permissionGranted = (reply == 'y')

        sqlPath = f"{cls.SQLDirectory}"
        sqlURLPath = "https://download.microsoft.com/download/5/E/9/5E9B18CC-8FD5-467E-B5BF-BADE39C51F73/SQLServer2017-SSEI-Expr.exe"
        print("Downloading {0:s} to {1:s}".format(sqlURLPath, sqlPath))

        #subprocess.call(["your code here", "nopause"])
        #./SQL ENU INSTALLPATH SQLDirectory
        return True

    #.\SQLServer2017-SSEI-Expr.exe /ENU /INSTALLPATH="C:\Users\ASUS\Desktop\test"
    #Winget install "Microsoft SQL Server 2017 Express" "Microsoft SQL Server Management"
    #https://download.microsoft.com/download/5/E/9/5E9B18CC-8FD5-467E-B5BF-BADE39C51F73/SQLServer2017-SSEI-Expr.exe
    #https://aka.ms/ssmsfullsetup
    #.\SSMS-Setup-ENU.exe /Install /SSMSInstallRoot="C:\Users\ASUS\Desktop\test"
    #.\DCEXEC.EXE -?