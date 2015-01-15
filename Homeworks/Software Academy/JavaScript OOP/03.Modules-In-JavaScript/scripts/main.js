define(['renderer', 'game'], function (Renderer, Game) {
	'use strict';
	var canvasElement = document.getElementById("snake-canvas"),
		startButton = document.getElementById("start-game-btn"),
		stopButton = document.getElementById("stop-game-btn"),
		canvasRenderer = Renderer.getCanvas(canvasElement),
		game = Game.get(canvasRenderer);

	game.changeRenderer(canvasRenderer);

	function performGameStart() {
		game.start();
	}

	function performGameStop() {
		game.stop();
	}

	startButton.addEventListener("click", function (ev) {
		performGameStart();
	});

	stopButton.addEventListener("click", function () {
		performGameStop();
	});
});