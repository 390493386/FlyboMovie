var VideoPlayer = function (selectorId) {
    this.playerInstance = document.getElementById(selectorId);
};

VideoPlayer.prototype = {
    initialize: function (link, trySeconds, events) {
        var self = this;
        trySeconds = isNaN(trySeconds) ? 5 : trySeconds;

        self.playerInstance.src = link;
        self.playerInstance.load();

        var completeTry = false;
        var canPlayFn = events && typeof events.onCheckCanPlay == 'function' ?
            events.onCheckCanPlay : function () {
                return true
            };
        self.playerInstance.addEventListener("play", function () {
            if (completeTry && !canPlayFn()) {
                self.pause();
            }
        });

        self.interval = setInterval(function () {
            var currentTime = self.playerInstance.currentTime;
            completeTry = currentTime >= trySeconds;
            if (completeTry && !canPlayFn()) {
                self.pause();
                if (events && typeof events.onCompleteTry == 'function') {
                    events.onCompleteTry();
                }
            }
        }, 1000);
    },
    play: function () {
        this.playerInstance.play();
    },
    pause: function () {
        this.playerInstance.pause();
    },
    close: function () {
        this.playerInstance.src = '';
        if (this.interval) {
            clearInterval(this.interval);
        }
    }
};