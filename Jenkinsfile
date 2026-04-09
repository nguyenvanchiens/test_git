pipeline {
    agent any
    parameters {
        choice(
            name: 'PROJECT',
            choices: ['ProjectTestGit', 'ProjectA', 'ProjectB', 'ProjectC'],
            description: 'Chọn project cần build'
        )
    }
    stages {
        stage('Build') {
            steps {
                bat "dotnet build ${params.PROJECT}/${params.PROJECT}.csproj"
            }
        }
        stage('Publish') {
            steps {
                bat "dotnet publish ${params.PROJECT}/${params.PROJECT}.csproj -c Release -o publish\\${params.PROJECT}"
            }
        }
        stage('Run App') {
            steps {
                bat """
                taskkill /IM ${params.PROJECT}.exe /F
                cd publish\\${params.PROJECT}
                start dotnet ${params.PROJECT}.dll
                """
            }
        }
    }
}
