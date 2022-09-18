function modifyWorker(worker){
    if(worker.dizziness){
        worker.levelOfHydrated += 0.1 * worker.weight * worker.experience;
        worker.levelOfHydrated = false;
    }

    return worker;
}

modifyWorker({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true });