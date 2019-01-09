# Open

This command-line utility opens a file with the associated program for the file extension.

For example, this opens a picture in a preview window:

```
..\My Pictures> open IMG143994.jpg
```

The following opens an explorer window in the current directory (Bob's directory):

```
C:\Users\Bob> open .
```

This is achieved through shell-execute and file associations set up on your computer. To change the program used to open a particular file, in explorer right-click the file, select "Open With" then "Choose another app". Before choosing the appropriate program, check the "Always use this app" box.


## Download

You can download `open` here: [open.exe](https://github.com/mrtimuk/open/releases/download/v1.0.0/open.exe) (5.5 KB)

No installation or configuration is needed, just be sure to put `open.exe` in your system path for easy access.