function tikTakToe(array){
    let board = [
    [false, false, false], 
    [false, false, false], 
    [false, false, false]];

    let ctr = 0;
    let draw = true;
    let player;

    for(let i = 0; i < array.length; i++){
        
        let m = Number(array[i][0]);
        let n = Number(array[i][2]);
        let cell =  board[m][n];

        if(cell != false){
            console.log("This place is already taken. Please choose another!");
        }else{
            cell = ctr % 2 == 0 ? 'X' : 'O';
            board[m][n] = cell;
            ctr++;
        }

        if(ctr == 9){
            break;
        }

        if(hasGameEndedWithWin(board)){
            draw = false;
            player = ctr % 2 == 0 ? 'O' : 'X';
            break;
        }

    }

    if(draw){
        console.log("The game ended! Nobody wins :(");
    }else{
        console.log(`Player ${player} wins!`); 
    }

    for(let i = 0; i < 3; i++){
        console.log(board[i].join('\t'));
    }

    function hasGameEndedWithWin(board){
        let condition1 = board[0][0] == board[0][1] && board[0][0] == board[0][2] && board[0][0] != false;
        let condition2 = board[1][0] == board[1][1] && board[1][0] == board[1][2] && board[1][0] != false;
        let condition3 = board[2][0] == board[2][1] && board[2][0] == board[2][2] && board[2][0] != false;

        let condition4 = board[0][0] == board[1][0] && board[0][0] == board[2][0] && board[0][0] != false;
        let condition5 = board[0][1] == board[1][1] && board[0][1] == board[2][1] && board[0][1] != false;
        let condition6 = board[0][2] == board[1][2] && board[0][2] == board[2][2] && board[0][2] != false;

        let condition7 = board[0][0] == board[1][1] && board[0][0] == board[2][2] && board[0][0] != false;
        let condition8 = board[0][2] == board[1][1] && board[0][2] == board[2][0] && board[0][2] != false;

        return condition1 || condition2 || condition3 || condition4   
            || condition5 || condition6 || condition7 || condition8;
    }
}

tikTakToe(
['0 0',
 '0 1',
 '1 0',
 '1 1',
 '2 2',
 '2 2',
 '2 1']);