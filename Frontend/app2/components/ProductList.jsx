function ProductList({ products, hasSearched }) {
    if (!hasSearched) {
      return null
    }
  
    if (products.length === 0) {
      return <p>No se encontraron productos.</p>
    }
  
    return (
      <div className="product-list">
        {products.map((product) => (
          <div key={product.id} className="product-item">
            <img src={product.image || "/placeholder.svg"} alt={product.title} />
            <h3>{product.title}</h3>
          </div>
        ))}
      </div>
    )
  }
  
  export default ProductList
  
  