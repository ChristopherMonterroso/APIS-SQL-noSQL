import { useState } from "react"
import SearchBar from "./components/SearchBar"
import ProductList from "./components/ProductList"
import "./App.css"

function App() {
  const [products, setProducts] = useState([])
  const [isLoading, setIsLoading] = useState(false)
  const [hasSearched, setHasSearched] = useState(false)

  const handleSearch = (searchTerm) => {
    setIsLoading(true)
    setHasSearched(true)

    // Simulamos una búsqueda con un temporizador
    setTimeout(() => {
      const mockProducts = [
        { id: 1, title: "Producto 1", image: "https://via.placeholder.com/150" },
        { id: 2, title: "Producto 2", image: "https://via.placeholder.com/150" },
        { id: 3, title: "Producto 3", image: "https://via.placeholder.com/150" },
      ]

      // Filtramos los productos basados en el término de búsqueda
      const filteredProducts = mockProducts.filter((product) =>
        product.title.toLowerCase().includes(searchTerm.toLowerCase()),
      )

      setProducts(filteredProducts)
      setIsLoading(false)
    }, 1500) // Simulamos un retraso de 1.5 segundos
  }

  return (
    <div className="app">
      <h1>Buscador de Productos</h1>
      <SearchBar onSearch={handleSearch} />
      {isLoading ? <h2>Buscando...</h2> : <ProductList products={products} hasSearched={hasSearched} />}
    </div>
  )
}

export default App

