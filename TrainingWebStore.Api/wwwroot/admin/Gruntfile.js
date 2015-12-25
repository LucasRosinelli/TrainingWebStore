module.exports = function (grunt) {
    grunt.initConfig({
        cssmin: {
            sitecss: {
                files: {
                    'public/dist/assets/css/styles-1.0.0.min.css': [
                        'bower_components/bootswatch/paper/bootstrap.css',
                        'bower_components/animate.css/animate.css',
                        'bower_components/font-awesome/css/font-awesome.css',
                        'bower_components/toastr/toastr.css',
                        'bower_components/ng-img-crop/compile/unminified/ng-img-crop.css',
                        'public/dev/assets/css/site.css'
                    ]
                }
            }
        },
        uglify: {
            options: {
                compress: true,
                mangle: false
            },
            applib: {
                src: [
                    'bower_components/jquery/dist/jquery.js',
                    'bower_components/bootstrap/dist/js/bootstrap.js',
                    'bower_components/toastr/toastr.js',
                    'bower_components/angular/angular.js',
                    'bower_components/angular-route/angular-route.js',
                    'bower_components/ng-img-crop/compile/unminified/ng-img-crop.js',
                    'app/app.js',
                    'app/routes.js',
                    'app/config.js',
                    'app/factories/account-factory.js',
                    'app/factories/category-factory.js',
                    'app/factories/product-factory.js',
                    'app/controllers/home/home-controller.js',
                    'app/controllers/account/login-controller.js',
                    'app/controllers/account/logout-controller.js',
                    'app/controllers/category/category-controller.js',
                    'app/controllers/product/product-list-controller.js',
                    'app/controllers/product/product-create-controller.js',
                    'app/controllers/product/product-edit-controller.js'
                ],
                dest: 'public/dist/assets/js/scripts-1.0.0.min.js'
            }
        },
        copy: {
            main: {
                files: [{
                    expand: true,
                    cwd: 'bower_components/font-awesome/fonts',
                    src: '**',
                    dest: 'public/dist/assets/fonts',
                    flatten: false
                },
                {
                    expand: true,
                    cwd: 'public/dev/assets/imgs',
                    src: '**',
                    dest: 'public/dist/assets/imgs',
                    flatten: false
                }]
            }
        },
        htmlmin: {
            dist: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {
                    'public/dist/index.html': 'public/dev/index.html',
                    'public/dist/pages/account/login.html': 'public/dev/pages/account/login.html',
                    'public/dist/pages/category/index.html': 'public/dev/pages/category/index.html',
                    'public/dist/pages/home/index.html': 'public/dev/pages/home/index.html',
                    'public/dist/pages/product/create.html': 'public/dev/pages/product/create.html',
                    'public/dist/pages/product/edit.html': 'public/dev/pages/product/edit.html',
                    'public/dist/pages/product/index.html': 'public/dev/pages/product/index.html',
                    'public/dist/pages/shared/headbar.html': 'public/dev/pages/shared/headbar.html'
                }
            }
        }
    });

    grunt.registerTask("dist", [
        'cssmin',
        'uglify',
        'copy',
        'htmlmin'
    ]);

    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');
}