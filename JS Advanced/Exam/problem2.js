class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = []; 
    }

    newAdditions(footballPlayers) {
        let invited = [];

        footballPlayers.forEach(p => {
            let [name, age, value] = p.split("/");
            age = Number(age);
            value = Number(value);

            if(this.invitedPlayers.some(i => i.name == name)) {
                let player = this.invitedPlayers.find(i => i.name == name);
                player.value = player.value < value ? value : player.value;
            } else {
                this.invitedPlayers.push({ name, age, value });
                invited.push(name);
            }
        });

        return `You successfully invite ${invited.join(", ")}.`;
    }

    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split("/");
        playerOffer = Number(playerOffer);

        let player = this.invitedPlayers.find(i => i.name == name)

        if(!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(player.value > playerOffer) {
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.value - playerOffer} million more are needed to sign the contract!`);
        }

        player.value = "Bought";

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age) {
        let player = this.invitedPlayers.find(i => i.name == name)

        if(!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if(player.age < age) {
            if(age - player.age < 5) {
                return `${name} will sign a contract for ${age - player.age} years with ${this.clubName} in ${this.country}!`;
            }

            return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
        } else {
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult() {
        this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name));

        return "Players list:\n" + this.invitedPlayers.map(p => `Player ${p.name}-${p.value}`).join("\n");
    }
}
