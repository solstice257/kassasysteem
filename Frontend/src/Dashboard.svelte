<svelte:head>
  <title>Welcome</title>
</svelte:head>

<script>

	async function Order (orderName, price, alcoholic) {

        console.log(orderName)

		fetch('https://localhost:7009/order/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify([{

                orderName: orderName,
                price: price,
                alcoholic: alcoholic
            }])     
        })
        .then(response => {
                console.log(response)
            })  
	}
</script>

<main>
	<h1>Login</h1>
	<button on:click={() => Order("Beer", 3, true)}>
        Order beer button
    </button>
</main>