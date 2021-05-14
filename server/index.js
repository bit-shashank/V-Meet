const util = require('util');
const io = require("socket.io")(3000);

io.on("connection", (socket) => {
	socket.userData = { x: 0, y: 0, z: 0 };

	socket.emit("setId", { id: socket.id });

	console.log(`Client Connected ${socket.id}`);


	socket.on("disconnect", () => {
		console.log("Player disconnected");
		socket.broadcast.emit("deletePlayer", { id: socket.id });
	});

	socket.on("init", (data) => {
		socket.userData .x=0;
		socket.userData.y=0;
		socket.userData.z=0;
		console.log("Init:"+data);
	});

	socket.on("update", (data) => {
		console.log("Here.");
		console.log(util.inspect(data, {showHidden: false, depth: null}));
		// x,y,z=data.split(",");

	});
});

setInterval(() => {
	const nsp = io.of("/");

	let pack = [];
	for (let id in io.sockets.sockets) {
		let socket = nsp.connected[id];
		if (socket.userData !== undefined) {
			let pos= userData.x+","+userData.y+","+userData.z;
			pack.push(pos);
		}
	}
	
	if (pack.length > 0){
		// console.log(pack);
		 io.sockets.emit("remoteData", pack);
	}
}, 40);
