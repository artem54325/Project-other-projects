﻿var audio = $('#sound-volume-funct-video');
audio.volume = 0.2;

$('#camera_but').click(function(){
          if(this.src.includes('camera_line')){
                  this.src = "images/video/camera.png";
          }else{
                  this.src = "images/video/camera_line.png";
          }
  });

$('#player_but').click(function () {
    alert('qwe');
          if(this.src.includes('player')){
                  this.src = "images/video/stop.png";
          }else{
                  this.src = "images/video/player.png";
          }
  });

  $('#headphones_but').click(function(){
          if(this.src.includes('headphones_line')){
                  this.src = "images/video/headphones.png";
          }else{
                  this.src = "images/video/headphones_line.png";
          }
  });

$('#sound_but').click(function(){
          if(this.src.includes('sound_no')){
                  this.src = "images/video/sound.png";
          }else{
                  this.src = "images/video/sound_no.png";
          }
  });
  $('#links_copy').click(function(){
          launch_toast("link", "Link copied!")
  });