pipeline {
    agent any

    parameters {
        string(name: 'PROJECT', defaultValue: 'ProjectTestGit', description: 'Project name')
    }

    stages {
        stage('Build') {
            steps {
                bat "dotnet build ${params.PROJECT}/${params.PROJECT}.csproj"
            }
        }

        stage('Publish') {
            steps {
                bat "dotnet publish ${params.PROJECT}/${params.PROJECT}.csproj -c Release -o publish"
            }
        }

        stage('Run App') {
            steps {
                bat """
                taskkill /IM ${params.PROJECT}.exe /F
                cd publish
                start dotnet ${params.PROJECT}.dll
                """
            }
        }
    }
}
