
set PATHTOWIX=c:\sd\pbqa\Utilities\External\WIX\bin

call %PATHTOWIX%\candle.exe NamenLitchInstallerMSM.wsx

call %PATHTOWIX%\light.exe NamenLitchInstallerMSM.wixobj