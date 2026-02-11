import { Canvas } from "@react-three/fiber"; // Three.js with react components
import { OrbitControls } from "@react-three/drei"; // camera, loaders, etc
import { Environment } from "@react-three/drei";
import Model from "./Model";
import './App.css'

function App() { 
  return (
    <Canvas>
      <ambientLight/>
      <directionalLight position={[5, 5, 5]} intensity={5} />
      <Environment preset="city" />
      <OrbitControls />
      <Model />
    </Canvas>
  );
}

export default App
