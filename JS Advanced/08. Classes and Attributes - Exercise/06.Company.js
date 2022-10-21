class Company {
    constructor() {
        this.departments = { };
    }

    addEmployee(...args) {
        if(args.some(a => !a || a == null || a == "" || args[1] < 0)) {
            throw new Error("Invalid input!");
        }

        if(!this.departments[args[3]]) {
            this.departments[args[3]] = [];
        }

        this.departments[args[3]].push({
            name: args[0], 
            salary: args[1], 
            position: args[2]   
        });

        return `New employee is hired. Name: ${args[0]}. Position: ${args[2]}`;
    }

    bestDepartment() {
        for(const d in this.departments) {
            this.departments[d].averageSalary = 
                this.departments[d].reduce((total, value) => total + value.salary, 0) / this.departments[d].length;
        }

        let bestDepartment = Object.keys(this.departments).sort((a, b) => {
            if(this.departments[a].averageSalary == this.departments[b].averageSalary) {
                return this.departments[a].localeCompare(this.departments[b]);
            }

            return this.departments[b].averageSalary - this.departments[a].averageSalary;
        })[0];

        return `Best Department is: ${bestDepartment}` + 
        `\nAverage salary: ${this.departments[bestDepartment].averageSalary.toFixed(2)}` + 
        `\n${this.departments[bestDepartment]
            .sort((a, b) => {
                if(a.salary == b.salary) {
                    return a.name.localeCompare(b.name);
                }

                return b.salary - a.salary;
            })
            .map(e => `${e.name} ${e.salary} ${e.position}`)
            .join('\n')}`;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
