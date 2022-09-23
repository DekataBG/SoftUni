function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let text = JSON.parse(document.querySelector('textarea').value);
      
      let restaurants = {};

      text.forEach(r => {
         r = r.split(' - ');
         let restaurantName = r[0];
         employees = r[1].split(', ').map(e => e.split(' ')); 

         if(!restaurants[restaurantName]){
            restaurants[restaurantName] = {};
         }

         employees.forEach(e => restaurants[restaurantName][e[0]] =  Number(e[1]));
      });

      let bestRestaurant = Object.keys(restaurants)
         .sort((a, b) => 
            calculateAverageSalary(restaurants[b]) - calculateAverageSalary(restaurants[a]))[0];

      let bestRestaurantResult = 
         `Name: ${bestRestaurant} ` + 
         `Average Salary: ${calculateAverageSalary(restaurants[bestRestaurant]).toFixed(2)} ` +  
         `Best Salary: ${calculateMaxSalary(restaurants[bestRestaurant]).toFixed(2)}`;

      let bestEmployeesResult = Object.keys(restaurants[bestRestaurant])
         .sort((a, b) => restaurants[bestRestaurant][b] - restaurants[bestRestaurant][a])
         .map(k => `Name: ${k} With Salary: ${restaurants[bestRestaurant][k]}`)
         .join(' ');

      document.querySelector('#bestRestaurant p').textContent = bestRestaurantResult;
      document.querySelector('#workers p').textContent = bestEmployeesResult;


      function calculateAverageSalary(employees){
         employees = Object.values(employees);

         let sum = employees.reduce((sum, current) => {
            return sum + current;
         }, 0);

         return sum / employees.length;
      }

      function calculateMaxSalary(employees){
         employees = Object.values(employees);

         let max = employees.reduce((max, current) => {
            return max < current ? current : max;
         }, employees[0]);

         return max;
      }
   }
}
