var audio = document.getElementById("sound-volume-funct-video");
 audio.volume = 0.2;

 $('#camera').click(function(){
         if(this.src.includes('camera_line')){
                 this.src = " ~/images/video/camera.png";
         }else{
                 this.src = " ~/images/video/camera_line.png";
         }
 });

 $('#player').click(function(){
         if(this.src.includes('player')){
                 this.src = " ~/images/video/stop.png";
         }else{
                 this.src = " ~/images/video/player.png";
         }
 });

 $('#sound').click(function(){
         if(this.src.includes('sound_no')){
                 this.src = " ~/images/video/sound.png";
         }else{
                 this.src = " ~/images/video/sound_no.png";
         }
 });