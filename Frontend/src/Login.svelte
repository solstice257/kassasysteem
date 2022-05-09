<svelte:head>
  <title>Welcome</title>
</svelte:head>

<script>
	let id = "";
	let loginMessage = "";

   async function fetchUsers() {
	const response = await fetch(
		`http://localhost:5065/user/get/${id}`
	);
	const data = await response.json();
	console.log(data)

	if (data != null) {
			loginMessage = "succesful login";
		} else {
			loginMessage = "unsuccesful login";
		}
   }
   </script>

<main>
	<h1>Login</h1>
	<input bind:value={id}>
	<button on:click={fetchUsers}> Login </button>
	<p>{loginMessage}</p>
   </main>