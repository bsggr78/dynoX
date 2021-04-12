Imports System
Imports Telegram.Bot
Imports System.Diagnostics
Imports System.Diagnostics.Process
Imports System.IO
Imports System.Threading

Module Program

    Dim ngrok As New Process
    Dim ttyd As New Process
   
    Dim exitcmd As Boolean
    Sub Main(Args As String())
        IO.Directory.CreateDirectory("/root/herokupatcher")
        ' IO.File.WriteAllBytes("/root/herokupatcher/ngrok", My.Resources.Resources.ngrok)
        'IO.File.WriteAllBytes("/root/herokupatcher/ttyd", My.Resources.Resources.ttyd)
        Process.Start("chmod", "+x /root/herokupatcher/ngrok")
        Process.Start("chmod", "+x /root/herokupatcher/ttyd")
        ngrok.StartInfo.FileName = "/root/herokupatcher/ngrok"
        ngrok.StartInfo.Arguments = "http 5143 -log=stdout"
        ngrok.StartInfo.WorkingDirectory = "/root/herokupatcher"
        ngrok.StartInfo.UseShellExecute = False

        ttyd.StartInfo.FileName = "/root/herokupatcher/ttyd"
        ttyd.StartInfo.Arguments = "-p 5143 bash"
        ttyd.StartInfo.WorkingDirectory = "/root/herokupatcher"
        ttyd.StartInfo.UseShellExecute = False
        ttyd.EnableRaisingEvents = True
        ttyd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        ttyd.StartInfo.CreateNoWindow = True




        ttyd.Start()
        System.Threading.Thread.Sleep(1200)

        'bot.SendTextMessageAsync(id, "TTYD >>" & vbCrLf & ttyd.StandardOutput.ReadToEnd)
        ngrok.Start()
        System.Threading.Thread.Sleep(1200)


        'bot.SendTextMessageAsync(id, "NGROK >>" & vbCrLf & ngrok.StandardOutput.ReadToEnd)
        'Dim fs As FileStream = System.IO.File.OpenRead("/root/herokupatcher/nohup.out")
        'Dim inputOnlineFile As Telegram.Bot.Types.InputFiles.InputOnlineFile = New Telegram.Bot.Types.InputFiles.InputOnlineFile(fs, "ngrok.txt")
        'bot.SendDocumentAsync(id, inputOnlineFile)
        Dim locker As New ManualResetEvent(false)
        locker.WaitOne()
      

    End Sub


End Module
