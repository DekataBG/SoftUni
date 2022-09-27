function attachEventsListeners() {
    let textboxes = Array.from(document.querySelectorAll("input[type='text']"));
    let buttons = Array.from(document.querySelectorAll("input[type='button']"));
    
    buttons.forEach(b => b.addEventListener("click", onClick));


    function onClick() {
        let input = this.parentNode.children[1];
        let unit = input.id; 
        let value = input.value;

        let seconds = convertToSeconds();

        textboxes.forEach(tb => fillTextBox(tb));

        
        function convertToSeconds() {
            switch(unit) {
                case "days":
                    return value * 24 * 60 * 60;
                case "hours": 
                    return value * 60 * 60;
                case "minutes": 
                    return value * 60;
                case "seconds": 
                    return value;
            }
        }

        function fillTextBox(tb){
            switch(tb.id) {
                case "days":
                tb.value = seconds / 24 / 60 / 60;
                break;
            case "hours": 
                tb.value = seconds / 60 / 60;
                break;
            case "minutes": 
                tb.value = seconds / 60;
                break;
            case "seconds": 
                tb.value = seconds;
                break;
            }
        }
    }
}