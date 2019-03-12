/**
 * Created by rainb on 2018/7/6.
 */
const path = require('path');

module.exports = {
    entry: './src/index.js',
    output: {
        path: path.resolve(__dirname, 'assets/js'),
        filename: 'index.js'
    }
};