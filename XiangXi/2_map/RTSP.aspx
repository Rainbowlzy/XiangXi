<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RTSP.aspx.cs" Inherits="XiangXi._2_map.RTSP" %>
<!DOCTYPE html>
<html>
<meta charset="utf-8" />

<head>
    <title>HTTP Live Streaming Example</title>
    <meta http-equiv="Access-Control-Allow-Origin" content="*">
	<style>
	#vlc{
            position: relative;
			width: 800px;
			height: 800px;
        }

	</style>
</head>

<body>
    <!-- rtsp暂时需要ie或者火狐浏览器 需要安装vlc-->
    <object type='application/x-vlc-plugin' pluginspage="http://www.videolan.org/" id='vlc' events='false' width="720" height="410">
    <param name='mrl' value='<%=Request.Params["src"]??"rtsp://122.193.16.161:554/pag://10.11.1.4:7302:32050690001310013655:0:MAIN:TCP" %>'
    <param name='autoplay' value='true' />
    <param name='loop' value='false' />
    <param name='fullscreen' value='false' />
    <param name='controls' value='false' />
</object>
</body>

</html>