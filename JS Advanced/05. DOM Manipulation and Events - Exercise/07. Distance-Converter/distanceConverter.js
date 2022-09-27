function attachEventsListeners() {
    let button = document.querySelector("input[type='button']");
    button.addEventListener("click", onClick);


    function onClick(){
        let [input, output] = document.querySelectorAll("input[type='text']");
        let [fromUnit, toUnit] = document.querySelectorAll("select");

        let distance = Number(input.value);
        let meters = getDistanceInMetres();

        let outputDistance = convertTo();
        output.value = outputDistance;

        function getDistanceInMetres() {
            switch(fromUnit.value) {
                case "km":
                    return distance * 1000;
                case "m":
                    return distance;
                case "cm":
                    return distance / 100; 
                case "mm":
                    return distance / 1000;
                case "mi":
                    return distance * 1609.34;  
                case "yrd":
                    return distance * 0.9144; 
                case "ft":
                    return distance * 0.3048 ;  
                case "in":
                    return distance * 0.0254;  
            }
        }

        function convertTo() {
            switch(toUnit.value) {
                case "km":
                    return meters / 1000;
                case "m":
                    return meters;
                case "cm":
                    return meters * 100; 
                case "mm":
                    return meters * 1000;
                case "mi":
                    return meters / 1609.34;  
                case "yrd":
                    return meters / 0.9144; 
                case "ft":
                    return meters / 0.3048 ;  
                case "in":
                    return meters / 0.0254;  
            }
        }
    }
}