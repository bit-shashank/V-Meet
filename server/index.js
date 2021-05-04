const io = require("socket.io")(3000);

io.on("connection", (socket) => {
	socket.userData = { x: 0, y: 0, z: 0 };

	socket.emit("setId", { id: socket.id });

	socket.on("disconnect", () => {
		console.log("Player disconnected");
		socket.broadcast.emit("deletePlayer", { id: socket.id });
	});

	socket.on("init", (data) => {
		console.log(data);
		socket.userData = data;
	});

	socket.on("update", (data) => {
		console.log("Update:" + data);
	});
});

setInterval(() => {
	const nsp = io.of("/");

	let pack = [];
	for (let id in io.sockets.sockets) {
		let socket = nsp.connected[id];
		if (socket.userData !== undefined) {
			pack.push(socket.userData);
		}
	}

	if (pack.length > 0) io.sockets.emit("remoteData", pack);
}, 40);
