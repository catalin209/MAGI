<template>
    <div class="filters-container">
        <div class="filter-category">
            <span class="category-name">Availability</span>
            <div class="checkbox">
                <label>
                    <input type="checkbox" :checked="filters.available" @click="availability()"/><i class="helper"></i>
                </label>
                In Stock
            </div>
        </div>

        <div class="filter-category">
            <span class="category-name">Price</span>
            <div class="checkbox" v-for="(priceRange,index) in priceRanges" :key="index">
                <label>
                    <input type="checkbox" :checked="filters.minPrice == priceRange.minPrice" @click="price(priceRange.minPrice, priceRange.maxPrice)"/><i class="helper"></i>
                </label>
                <span v-if="priceRange.minPrice < 1000">
                    {{priceRange.minPrice}} - {{priceRange.maxPrice}}
                </span>
                <span v-else>
                    {{priceRange.minPrice}}+
                </span>
            </div>
        </div>

        <div class="filter-category">
            <span class="category-name">Country</span>
            <div class="checkbox">
                <label>
                    <input type="checkbox" :checked="filters.isInternational" @click="country()"/><i class="helper"></i>
                </label>
                International
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            selectedFilters: {
                type: Object
            },
        },

        created() {
            this.filters = this.selectedFilters
        },

        data: () => {
            return {
                filters: {
                    minPrice: 0,
                    maxPrice: 99999,
                    available: false,
                    isInternational: false
                },
                priceRanges: [
                    {
                        minPrice: 100,
                        maxPrice: 200
                    },
                    {
                        minPrice: 200,
                        maxPrice: 500
                    },
                    {
                        minPrice: 500,
                        maxPrice: 1000
                    },
                    {
                        minPrice: 1000,
                        maxPrice: null
                    },
                ],
            }
        },

        methods: {
            availability() {
                this.filters.available = !this.filters.available
                this.$emit('selectFilters', this.filters)
            },
            price(min, max) {
                this.filters.minPrice = min
                this.filters.maxPrice = max
                this.$emit('selectFilters', this.filters)
            },
            country() {
                this.filters.isInternational = !this.filters.isInternational
                this.$emit('selectFilters', this.filters)
            },
        },
    }
</script>

<style scoped>
    .filters-container {
        flex: 1;
        margin: 100px 30px 0px 50px;
        background: #fff;
        -webkit-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        -moz-box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        box-shadow: 0px 1px 3px 0px rgba(0,0,0,0.75);
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-direction: column;
        height: calc(100vh - 150px);
        overflow: hidden;
        position: relative;
    }
    .filters-container .filter-category {
        display: flex;
        justify-content: flex-start;
        align-items: flex-start;
        flex-direction: column;
        margin-top: 35px;
        width: 100%;
        padding-left: 50px;
    }
    .filters-container .filter-category .category-name {
        margin-bottom: 5px;
        font-weight: 700;
    }
    .filters-container .filter-category .checkbox {
        width: 100%;
        display: flex;
        justify-content: flex-start;
        height: 32px;
        position: relative;
        top: 8px;
        margin: 0px;
    }
    .filters-container .filter-category .checkbox label {
        margin-top: -2px;
    } 
</style>