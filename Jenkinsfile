node {
    stage('Clone repository') {
        git branch: 'master',
            credentialsId: 'matheusoliveira-github-ssh',
            url: 'https://github.com/matheusmco/SistemaPessoal.git'
    }

    stage('Build .NET')
    {
        sh 'dotnet build'
    }

    stage('Build Image') {
        /* This builds the actual image; synonymous to
         * docker build on the command line */
        app = docker.build("matheusoliveira/sistema.pessoal.api") 
    } 

    stage('Push to registry') {
        docker.withRegistry('https://registry.hub.docker.com', 'docker-registry') {
            app.push("0.1")
        }
    }
}