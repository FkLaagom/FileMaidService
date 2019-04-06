# FileMaidService
A simple service using Topshelf that reorganize files in system download folder

### Service in Action:

![Alt Text](https://github.com/FkLaagom/FileMaidService/blob/master/MD/FilemaidDemo.gif)
*EDIT: Now using System.Timers instead of System.IO.FileSystemWatcher.
Reorganization will therefore be triggered by time based intervals rather than on file change, making it easier to find recently downloaded files.*



### Set Folder - FileFormat mapping using FileMaid.cs GetFolders():
![Alt Text](https://github.com/FkLaagom/FileMaidService/blob/master/MD/Filemapping.png)


### Service Installed:
![Alt Text](https://github.com/FkLaagom/FileMaidService/blob/master/MD/ServiceRunning.png)
