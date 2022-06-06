<template>
  <div class="hello">
    <h1>{{ msg }}</h1>

    <select name="my_html_select_box">
      <option selected="yes"> - Selecciona una categoría - </option>
      <option>RTS - Real-Time Strategy</option>
      <option>FPS - First Person Shooter</option>
      <option>MOBA - Multiplayer Online Battle Arena</option>
      <option>RP - Role-Playing</option>
    </select>
    <input type="submit" id="lname" value="Buscar">
    
  </div>
</template>

<script>
export default {
  name: 'Home',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
