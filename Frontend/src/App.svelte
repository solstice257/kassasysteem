<script>
	let name = "Users";
	let users = [];
   async function fetchUsers() {
	const response = await fetch(
	"https://localhost:7087/users"
	);
	const data = await response.json();
	users = data
	console.log(data)
   }
   </script>

<main>
	<h1>{name}</h1>
	<button on:click={fetchUsers}>Fetch users</button>
	{#each users as user}
	  <p>Userid: {user.userId}</p>
	  <p>Name: {user.name}</p>
	  <p>Citizenship: {user.citizenship}</p>
	  <br>
	{/each}
   </main>