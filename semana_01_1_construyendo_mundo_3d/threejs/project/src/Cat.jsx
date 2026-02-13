import { OBJLoader } from 'three/addons/loaders/OBJLoader.js'
import { useLoader } from '@react-three/fiber'

function Cat() {
  const obj = useLoader(OBJLoader, '/models/cat.obj')
  return <primitive object={obj} />
}

export default Cat;
