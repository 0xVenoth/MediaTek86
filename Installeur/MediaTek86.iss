; Script Inno Setup pour l'installation de l'application MediaTek86
; Genere un fichier MediaTek86-Installeur.exe installable sur un autre poste.

[Setup]
AppName=MediaTek86
AppVersion=1.0
AppPublisher=MediaTek86
DefaultDirName={autopf}\MediaTek86
DefaultGroupName=MediaTek86
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=MediaTek86-Installeur
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "Creer un raccourci sur le Bureau"; GroupDescription: "Raccourcis :"

[Files]
; Application et toutes ses dependances (.NET Framework 4.7.2)
Source: "..\MediaTek86\bin\Release\net472\*"; DestDir: "{app}"; Excludes: "*.pdb"; Flags: ignoreversion recursesubdirs createallsubdirs
; Script de creation de la base de donnees (fourni a l'utilisateur)
Source: "..\mediatek86.sql"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\MediaTek86"; Filename: "{app}\MediaTek86.exe"
Name: "{group}\Desinstaller MediaTek86"; Filename: "{uninstallexe}"
Name: "{autodesktop}\MediaTek86"; Filename: "{app}\MediaTek86.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\MediaTek86.exe"; Description: "Lancer MediaTek86"; Flags: nowait postinstall skipifsilent
