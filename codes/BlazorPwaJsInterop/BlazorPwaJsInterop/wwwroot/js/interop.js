window.jsFunctions = {
    showAlert: function (message) {
        alert(message);
    },
    changeBackgroundColor: function (color) {
        document.body.style.backgroundColor = color;
    },
    getBrowserInfo: function () {
        return navigator.userAgent;
    }
};