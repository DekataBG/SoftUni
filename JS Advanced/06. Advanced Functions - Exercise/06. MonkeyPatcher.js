function solution(command){
    switch (command) {
        case 'upvote': 
            this.upvotes++;
            return [];
        case 'downvote': 
            this.downvotes++;
            return [];
        case 'score': 
            let total = this.upvotes + this.downvotes;
            let added = total > 50 ? Math.ceil(Math.max(this.upvotes, this.downvotes) / 4) : 0;

            let balance = this.upvotes - this.downvotes;

            if(this.upvotes / (total) > 0.66){
                this.rating = 'hot';
            } else if(balance >= 0 && this.downvotes + this.downvotes > 100) {
                this.rating = 'controversial';
            } else if(balance < 0) {
                this.rating = 'unpopular';
            } else {
                this.rating = 'new';
            }

            if(this.upvotes + this.downvotes < 10) {
                this.rating = 'new';
            }
            

            return [this.upvotes + added, this.downvotes + added, balance, this.rating];
    }
}


var forumPost = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(forumPost, 'upvote');
solution.call(forumPost, 'downvote');

var answer = solution.call(forumPost, 'score');
console.log(answer);

var expected = [127, 127, 0, 'controversial'];
//compareScore(expected, answer);

// 50 Downvotes
for (let i = 0; i < 50; i++) {
    solution.call(forumPost, 'downvote');
}
answer = solution.call(forumPost, 'score');
console.log(answer);
expected = [139, 189, -50, 'unpopular'];

//compareScore(expected, answer);

// function compareScore(expected, answer) {
//     expect(expected[0]).to.equal(answer[0], 'Incorrect number of upvotes');
//     expect(expected[1]).to.equal(answer[1], 'Incorrect number of downvotes');
//     expect(expected[2]).to.equal(answer[2], 'Incorrect score');
//     expect(expected[3]).to.equal(answer[3], 'Incorrect rating');
// }