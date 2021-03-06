; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "ChangeBackgroundWin"
#define MyAppVersion "3.300"
#define MyAppPublisher "HackerNCoder"
#define MyAppURL "http://5.175.25.50/ChangeBackgroundWin/"
#define MyAppExeName "Update.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{077A6BFF-F592-44F4-A928-8112EAA82693}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename=PreRelease
SetupIconFile=E:\Copy from dads\ChangeBackgroundWin\CBWLogo.ico
Compression=lzma
SolidCompression=yes
UninstallDisplayIcon={app}\CBWLogo.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\Copy from dads\ChangeBackgroundWin\Update\bin\Debug\Update.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Copy from dads\ChangeBackgroundWin\ChangeBackgroundWin\bin\Debug\ChangeBackgroundWin.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Copy from dads\ChangeBackgroundWin\ChangeBackgroundControlPanel\bin\Debug\ChangeBackgroundControlPanel.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "E:\Copy from dads\ChangeBackgroundWin\settings.acf"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Copy from dads\ChangeBackgroundWin\ChangeBackgroundWin\bin\Debug\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "E:\Copy from dads\ChangeBackgroundWin\_urlLists\fineurls.txt"; DestDir: "{app}"; Flags: ignoreversion
;Source: "E:\Copy from dads\ChangeBackgroundWin\_urlLists\nogourls.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\Copy from dads\ChangeBackgroundWin\CBWLogo.ico"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent