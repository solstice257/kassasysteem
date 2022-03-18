<script>
	let name = "TEST";
	let products = [];
   async function fetchProducts() {
	const response = await fetch(
	"https://localhost:5000/api/Products"
	);
	const data = await response.json();
	products = data
	console.log(data)
   }
   </script>

<main>
	<h1>{name}</h1>
	<button on:click={fetchProducts}>Fetch products!</button>
	{#each products as product}
	  <p>{product.productId}</p>
	  <p>{product.productName}</p>
	  <p>{product.productPrice}</p>
	  <br>
	{/each}
   </main>