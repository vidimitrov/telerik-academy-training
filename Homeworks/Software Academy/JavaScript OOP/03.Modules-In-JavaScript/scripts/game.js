define(['snake'], function (Snake) {

	function Game(renderer) {
		this.renderer = renderer;
		this.snake = Snake.get(250, 250, 10);
		this.bindKeyEvents();
		this.state = "stopped";
	}

	function animationFrame() {
		var snakePosition = theGame.snake.getPosition(),
			toChangePosition = false,
			newX = snakePosition.x,
			newY = snakePosition.y;

		if (snakePosition.x < dimensions.minWidth) {
			newX = dimensions.maxWidth;
			toChangePosition = true;
		} else if (dimensions.maxWidth < snakePosition.x) {
			newX = dimensions.minWidth;
			toChangePosition = true;
		}
		if (snakePosition.y < dimensions.minHeight) {
			newY = dimensions.maxHeight;
			toChangePosition = true;
		}
		if (dimensions.maxHeight < snakePosition.y) {
			newY = dimensions.minHeight;
			toChangePosition = true;
		}
		if (toChangePosition) {
			theGame.snake.changePosition(newX, newY);
		}

		theGame.renderer.clear();
		theGame.snake.move();
		theGame.renderer.draw(theGame.snake);

		if (theGame.state === "running") {
			requestAnimationFrame(animationFrame);
		}
	}

	var dimensions;
	Game.prototype = {
		start: function () {
			theGame = this;
			requestAnimationFrame(animationFrame);
			dimensions = this.renderer.getDimensions();
			this.state = "running";
		},
		stop: function () {
			theGame.state = "stopped";
		},
		bindKeyEvents: function () {
			var self = this;
			document.body.addEventListener("keydown", function (ev) {
				var keyCode = ev.keyCode;
				if (37 <= keyCode && keyCode <= 40) {
					self.snake.changeDirection(keyCode - 37);
				}
			});
		},
		getState: function () {
			return this.state;
		},
		changeRenderer: function (newRenderer) {
			this.renderer = newRenderer;
		}
	}

	return {
		get: function (renderer) {
			return new Game(renderer);
		}
	};
});