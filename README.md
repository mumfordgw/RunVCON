# RunVCON
# Some proof of concept code to run a Windows program. The program originally had two start menu shortcuts to run the same executble in different working directories. This no longer works on Windows 10 and Server 2016 (it probably didn't work on Windows 8 either) in that Windows only shows one of the shortcuts. Multiple shortcuts to the same executable are prohibited according to MSDN. This code helps get around this issue as it can be copied to files with different names which will appear in the Start Menu. The shortcuts on the Start Menu can also be customised to run the program in different working directories.
