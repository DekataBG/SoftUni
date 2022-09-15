function makeNewArray(array, target1, target2){
    let index1 = array.indexOf(target1);
    let index2 = array.indexOf(target2);

    let newArray = array.splice(index1, index2 - index1 + 1);

    return newArray;
}

makeNewArray(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie');