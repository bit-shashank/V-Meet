let scene= new THREE.Scene();
let camera= new THREE.PerspectiveCamera(75,window.innerWidth/window.innerHeight,0.1,1000);

let renderer=new THREE.WebGLRenderer({antialias:true});

renderer.setClearColor("#e5e5e5");
renderer.setSize(window.innerWidth,window.innerHeight);

document.body.appendChild(renderer.domElement);


window.addEventListener("resize",()=>{
    camera.aspect=(window.innerWidth/window.innerHeight);
    renderer.setSize(window.innerWidth,window.innerHeight);
    camera.updateProjectionMatrix();
})

renderer.render(scene,camera);