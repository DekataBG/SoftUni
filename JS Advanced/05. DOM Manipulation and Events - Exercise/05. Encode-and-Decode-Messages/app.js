function encodeAndDecodeMessages() {
    let [firstButton, secondButton] = document.querySelectorAll("#main div button");
    let [firstTextArea, secondTextArea] = document.querySelectorAll("#main div textarea");

    firstButton.addEventListener("click", transform);
    secondButton.addEventListener("click", transform);

    function transform() {
        let disabled = this.parentNode.querySelector("textarea").disabled;
        let message = disabled ? secondTextArea.value : firstTextArea.value;

        let newMessage = [];

        for(let i = 0; i < message.length; i++) {
            let ascii = message.charCodeAt(i);
            let newAscii = disabled ? ascii - 1 : ascii + 1;

            newMessage[i] = String.fromCharCode(newAscii);
        }

        secondTextArea.value = newMessage.join('');

        firstTextArea.value = "";
    }
}