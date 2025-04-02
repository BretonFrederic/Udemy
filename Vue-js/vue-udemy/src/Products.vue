<script>
export default {
    data(){
        return{
            products:[
                {'id': 1, 'name': 'A', 'unit_price': 10, 'quantity': 5, 'description': '<b>genial</b>'},
                {'id': 2, 'name': 'B', 'unit_price': 25, 'quantity': 4, 'description': '<b>genial 1</b>'},
                {'id': 3, 'name': 'C', 'unit_price': 8, 'quantity': 1, 'description': '<b>genial 2</b>'},
                {'id': 4, 'name': 'D', 'unit_price': 40, 'quantity': 10, 'description': '<b>genial 3</b>'},
                {'id': 5, 'name': 'E', 'unit_price': 18, 'quantity': 3, 'description': '<b>genial</b>'},
                {'id': 6, 'name': 'F', 'unit_price': 22, 'quantity': 2, 'description': '<b>genial</b>'},
                {'id': 7, 'name': 'G', 'unit_price': 35, 'quantity': 7, 'description': '<b>genial</b>'},
                {'id': 8, 'name': 'H', 'unit_price': 54, 'quantity': 6, 'description': '<b>genial</b>'},
                {'id': 9, 'name': 'I', 'unit_price': 16, 'quantity': 8, 'description': '<b>genial</b>'},
                {'id': 10, 'name': 'J', 'unit_price': 64, 'quantity': 8, 'description': '<b>genial</b>'}
            ]
        }
    }
}
</script>

<template>
    <div>
        <h1>nos produits</h1>
        <div>
            <div class="product" v-for="product in products" :key="product.id">
                <h3>{{ product.name }}</h3>
                <div>
                    <p>
                        <b>Prix unitaire:</b>{{ product.unit_price }} €<br>
                        <b>Quantité:</b> {{ product.quantity }} en stock
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>

</style>