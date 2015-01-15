window.onload = function(){
    var canvas = document.createElement('canvas');
    canvas.style.border = '1px solid black';
    canvas.width = 300;
    canvas.height = 100;

    var ctx = canvas.getContext('2d');
    document.body.appendChild(canvas);
    //var frame = 0;
    var super_mario_front;
    var super_mario_back;

    var img = new Image();
    img.onload = function() {
        initSprites(this);

        run();
    }
    img.src = "sprite.png";

    run();

    //The Super Mario object
    var super_mario = {
        x: 0,
        y: 0,
        frame: 0,
        acceleration: 1,
        velocity: 0,
        animation: [0, 1, 2, 3, 4],

        update: function(){
            this.x += this.acceleration;
            this.frame++;
            if(this.frame >= 5){
                this.frame = 0;
            }
            if(this.x >= canvas.width || this.x <= 0){
                this.acceleration *= -1;
            }
        },
        draw: function(ctx){
            ctx.save();

            ctx.translate(this.x, this.y);
            var n = this.animation[this.frame];
            //if this.acceleration < 0 - back, else front...
            super_mario_front[n].draw(ctx, -super_mario_front[n].x, -super_mario_front[n].y);
            //console.log(super_mario_front[n]);
            //debugger;
            ctx.restore();
        }
    }

    //Declaring a simple class for the sprites
    function Sprite(img, x, y, width, height) {
        this.img = img;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;

    };

    Sprite.prototype.draw = function(ctx, x, y) {
        ctx.drawImage(this.img, this.x, this.y, this.width, this.height,
            x, y, this.width, this.height);
    };

    //16x22 is the default image of one Mario

    function initSprites(image){
        super_mario_front = [
            //1 --- 0, 0
            //2 --- 17, 0
            //3 --- 34, 0
            //4 --- 50, 0
            //5 --- 65, 0
            //6 --- 82, 0
            //7 --- 99, 0
            //8 --- 116, 0
            //9 --- 133, 0
            //[1,2,7,8,9]
            new Sprite(img, 0, 0, 16, 22),
            new Sprite(img, 17, 0, 16, 22),
            new Sprite(img, 99, 0, 16, 22),
            new Sprite(img, 116, 0, 16, 22),
            new Sprite(img, 133, 0, 16, 22)
        ];

        super_mario_back = [
            //1 --- 0, 23
            //2 --- 17, 23
            //3 --- 34, 23
            //4 --- 50, 23
            //5 --- 65, 23
            //6 --- 82, 23
            //7 --- 99, 23
            //8 --- 116, 23
            //9 --- 133, 23
            new Sprite(img, 156, 115, 17, 12),
            new Sprite(img, 156, 128, 17, 12),
            new Sprite(img, 156, 141, 17, 12),
            new Sprite(img, 156, 141, 17, 12)
        ];
    }

    function run(){
        var loop = function() {
            update();
            render();
            window.requestAnimationFrame(loop, canvas);
        }
        window.requestAnimationFrame(loop, canvas);
    }

    function update() {
//        if(frame < 5){
//            frame++;
//        }
//        else{
//            frame = 0;
//        }
        super_mario.update();
    }

    function render(){
        ctx.clearRect(0, 0, 700, 400);
        super_mario.draw(ctx);
    }
};