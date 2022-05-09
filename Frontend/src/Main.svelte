<script>
    import { Router, Route, Link } from "svelte-navigator";
    import Login from "./Login.svelte";
    import Dashboard from "./Dashboard.svelte";
  
  </script>
  
  <Router>
    <main>
      <Route path="dashboard">
        <Dashboard />
      </Route>
  
      <Route path="/">
        <Login />
      </Route>
    </main>
  </Router>