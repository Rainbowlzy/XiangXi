<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RTSP.aspx.cs" Inherits="XiangXi._2_map.RTSP" %>
<%
// Response.AppendHeader("Access-Control-Allow-Origin", "*");
%>
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
    <%=Request.Params["url"].Split(',')[0] %>
    <video class="video-js" controls preload="auto" width="710" height="400"
    poster="MY_VIDEO_POSTER.jpg" data-setup="{}">
      <source
       src="<%=Request.Params["url"].Split(',')[0] %>"
       type="application/x-mpegURL">
      <p class="vjs-no-js">
        To view this video please enable JavaScript, and consider upgrading to a web browser that
        <a href="https://videojs.com/html5-video-support/" target="_blank">supports HTML5 video</a>
      </p>
    </video>

    <script src="https://vjs.zencdn.net/7.1.0/video.js"></script>
</object>
</body>

</html>