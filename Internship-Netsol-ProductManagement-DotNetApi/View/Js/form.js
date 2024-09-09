document.getElementById('product-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    // Gather form data
    const productData = {
        name: document.getElementById('name').value,
        description: document.getElementById('description').value,
        price: parseFloat(document.getElementById('price').value)
    };

    // Send the POST request to the API
    try {
        const response = await fetch('https://localhost:5001/api/product', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(productData)
        });

        if (response.ok) {
            alert('Product created successfully!');
            fetchProducts();  // Refresh the product list
        } else {
            alert('Error: ' + response.statusText);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Error submitting form');
    }
});

// Function to fetch and display products
async function fetchProducts() {
    try {
        const response = await fetch('https://localhost:5001/api/product');
        const products = await response.json();

        const productList = document.getElementById('product-list');
        productList.innerHTML = '';

        products.forEach(product => {
            const productItem = document.createElement('div');
            productItem.innerHTML = `<p>${product.name} - $${product.price}</p>`;
            productList.appendChild(productItem);
        });
    } catch (error) {
        console.error('Error fetching products:', error);
    }
}

// Fetch products when the page loads
fetchProducts();
