pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        withDotNet(sdk: '8.0') {
          dotnetNuGetLocals()
          dotnetClean()
          dotnetToolRestore()
          dotnetRestore()
          dotnetBuild()
          dotnetTest()
        }

      }
    }
  }

    post {
      failure {
        script {
          httpRequest(url: "http://${apiurl}/api/v1.0/CiCD/jenkins-failed-build", acceptType: 'TEXT_PLAIN', consoleLogResponseBody: true, contentType: 'APPLICATION_JSON', httpMode: 'POST', responseHandle: 'STRING', requestBody: "{ buildId: '${env.BUILD_ID}', buildNumber: '${env.BUILD_NUMBER}', buildTag: '${env.BUILD_TAG}', buildUrl: '${env.BUILD_URL}', executorNumber: '${env.EXECUTOR_NUMBER}', javaHome: '${env.JAVA_HOME}', jenkinsUrl: '${env.JENKINS_URL}', jobName: '${env.JOB_NAME}', nodeName: '${env.NODE_NAME}', workspace: '${env.WORKSPACE}' }")
        }
      }
    }
  
}
