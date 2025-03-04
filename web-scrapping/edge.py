from selenium import webdriver
from selenium.webdriver.edge.service import Service
from webdriver_manager.microsoft import EdgeChromiumDriverManager
from selenium.webdriver.common.by import By
import time

def obtener_precio_edge(codigo):
    url = f"https://guatemaladigital.com/producto/{codigo}"

    options = webdriver.EdgeOptions()
    options.add_argument("--headless") 
    options.add_argument("--disable-gpu")
    options.add_argument("--no-sandbox")

    driver = webdriver.Edge(service=Service(EdgeChromiumDriverManager().install()), options=options)

    try:
        driver.get(url)
        time.sleep(3) 
        h4_precio = driver.find_element(By.CLASS_NAME, "priceProDetalle")
        span_precio = h4_precio.find_element(By.XPATH, './/span[@class="naranja-text span-text-producto font-weight-bold"]/span')
        precio = h4_precio.text
        
        return precio
    except Exception as e:
        return f"Error al obtener el precio: {str(e)}"
    finally:
        driver.quit() 

codigo_producto = "15626072"
precio = obtener_precio_edge(codigo_producto)
print(f"El precio del producto {codigo_producto} es: {precio}")
